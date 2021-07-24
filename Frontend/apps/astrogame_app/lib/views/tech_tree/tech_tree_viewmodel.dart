import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/conditions/levelable_condition.dart';
import 'package:astrogame_app/models/conditions/one_time_condition.dart';
import 'package:astrogame_app/models/tech_tree/tech_tree_condition_node.dart';
import 'package:astrogame_app/models/tech_tree/tech_tree_technology_node.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/providers/technologies_provider.dart';
import 'package:graphview/GraphView.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class TechTreeViewModel extends FutureViewModel {
  TechnologiesProvider _technologiesProvider;

  Technology _technology;
  FinishedTechnology _finishedTechnology;

  Graph graph;
  SugiyamaConfiguration builder;

  TechTreeViewModel(
    this._technologiesProvider,
    @factoryParam this._technology,
    @factoryParam this._finishedTechnology,
  ) {
    graph = Graph()..isTree = true;
    builder = new SugiyamaConfiguration();
  }

  List<Technology> _technologies;
  List<Technology> get technologies => _technologies;
  set technologies(List<Technology> val) {
    _technologies = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    technologies = await _fetchTechnologiesAsync();

    generateRootNode(_technology);

    builder
      // ..siblingSeparation = (100)
      ..levelSeparation = (150)
      //..subtreeSeparation = (150)
      ..orientation = (BuchheimWalkerConfiguration.ORIENTATION_LEFT_RIGHT);
  }

  Future<List<Technology>> _fetchTechnologiesAsync() async {
    return await _technologiesProvider.get();
  }

  static bool isConditionFulfilled(
    Condition condition,
    FinishedTechnology finishedTechnology,
  ) {
    if (finishedTechnology == null) {
      return false;
    }

    if (condition is LevelableCondition) {
      return finishedTechnology.level >= (condition).neededLevel;
    } else if (condition is OneTimeCondition) {
      return finishedTechnology != null;
    }

    return false;
  }

  void generateRootNode(Technology technology) {
    var nodeModel = new TechTreeTechnologyNode(technology);

    var node = Node.Id(nodeModel);

    graph.addNode(node);

    technology.neededConditions?.forEach((condition) {
      var subTechnology =
          technologies.firstWhere((e) => e.id == condition.neededTechnologyId);

      if (subTechnology == null) {
        return;
      }

      generateSubNode(node, subTechnology, null, condition);
    });
  }

  void generateSubNode(
    Node parentNode,
    Technology technology,
    FinishedTechnology finishedTechnology,
    Condition condition,
  ) {
    var nodeModel =
        new TechTreeConditionNode(technology, finishedTechnology, condition);

    var node = Node.Id(nodeModel);
    graph.addEdge(node, parentNode);

    technology.neededConditions?.forEach((condition) {
      var subTechnology =
          technologies.firstWhere((e) => e.id == condition.neededTechnologyId);

      if (subTechnology == null) {
        return;
      }

      generateSubNode(node, subTechnology, null, condition);
    });
  }
}
