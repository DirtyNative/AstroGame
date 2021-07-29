import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/conditions/levelable_condition.dart';
import 'package:astrogame_app/models/conditions/one_time_condition.dart';
import 'package:astrogame_app/models/tech_tree/tech_tree_condition_node.dart';
import 'package:astrogame_app/models/tech_tree/tech_tree_technology_node.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:graphview/GraphView.dart';
import 'package:stacked/stacked.dart';

import 'tech_tree_viewmodel.dart';

class TechTreeView extends StatelessWidget {
  final Technology _technology;

  TechTreeView(this._technology);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<TechTreeViewModel>.reactive(
      builder: (context, model, snapshot) => ScaffoldBase(
        body: SizedBox(
          height: 400,
          width: 400,
          child: InteractiveViewer(
            constrained: false,
            scaleEnabled: false,
            maxScale: 1,
            minScale: 1,
            boundaryMargin: EdgeInsets.all(100),
            child: GraphView(
              algorithm: SugiyamaAlgorithm(
                model.builder,
                //TreeEdgeRenderer(model.builder),
              ),
              graph: model.graph,
              paint: Paint()
                ..color = Colors.green
                ..strokeWidth = 1
                ..style = PaintingStyle.stroke,
              builder: (Node node) {
                if (node.key!.value is TechTreeConditionNode) {
                  return conditionNode(node.key!.value);
                } else if (node.key!.value is TechTreeTechnologyNode) {
                  return rootNode(node.key!.value);
                }

                return Container(
                  width: 100,
                  height: 100,
                );
              },
            ),
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(param1: _technology),
    );
  }

  Widget _conditionText(
      Condition condition, FinishedTechnology? finishedTechnology) {
    if (condition is LevelableCondition) {
      if (TechTreeViewModel.isConditionFulfilled(
          condition, finishedTechnology)) {
        return Text('${finishedTechnology?.level ?? 0}');
      } else {
        return Text(
            '${finishedTechnology?.level ?? 0} / ${condition.neededLevel}');
      }
    } else if (condition is OneTimeCondition) {
      if (TechTreeViewModel.isConditionFulfilled(
          condition, finishedTechnology)) {
        return Text('Built');
      } else {
        return Text('Not built');
      }
    }

    return Text('');
  }

  Widget rootNode(TechTreeTechnologyNode nodeModel) {
    return InkWell(
      child: Container(
        height: 100,
        width: 200,
        padding: EdgeInsets.all(16),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(8),
          gradient: LinearGradient(
            colors: [
              AstroGameColors.purple,
              AstroGameColors.torque,
            ],
          ),
        ),
        child: Column(
          children: [
            // Technology name
            Text(nodeModel.technology.name),
          ],
        ),
      ),
    );
  }

  Widget conditionNode(TechTreeConditionNode nodeModel) {
    return InkWell(
      child: Container(
        height: 100,
        width: 200,
        padding: EdgeInsets.all(16),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(8),
          gradient: LinearGradient(
            colors: [
              AstroGameColors.purple,
              AstroGameColors.torque,
            ],
          ),
        ),
        child: Column(
          children: [
            // Technology name
            Text(nodeModel.technology.name),

            _conditionText(nodeModel.condition, nodeModel.finishedTechnology),
          ],
        ),
      ),
    );
  }
}
