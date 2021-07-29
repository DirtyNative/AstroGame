import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/providers/research_provider.dart';
import 'package:astrogame_app/views/technologies/technologies_viewmodel.dart';
import 'package:injectable/injectable.dart';
import 'package:dartx/dartx.dart';

@injectable
class ResearchesViewModel extends TechnologiesViewModel {
  ResearchProvider _researchProvider;

  ResearchesViewModel(this._researchProvider);

  List<Research> get physicsResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.physics)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get engineeringResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.engineering)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get biologyResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.biology)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get socialResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.social)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get astronomyResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.astronomy)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get industryResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.industry)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get militaryResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.military)
      .sortedBy((element) => element.order)
      .toList();
  List<Research> get newWorldsResearches => (technologies as List<Research>)
      .where((element) => element.researchType == ResearchType.newWorlds)
      .sortedBy((element) => element.order)
      .toList();

  @override
  Future<List<Technology>> fetchTechnologiesAsync() async {
    return await _researchProvider.get();
  }
}
