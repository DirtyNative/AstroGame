import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/providers/research_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:dartx/dartx.dart';

@injectable
class ResearchesViewModel extends FutureViewModel {
  ResearchProvider _researchProvider;

  ResearchesViewModel(this._researchProvider);

  List<Research> _researches;
  List<Research> get researches => _researches;
  set researches(List<Research> val) {
    _researches = val;
    notifyListeners();
  }

  int _selectedTabIndex = 0;
  int get selectedTabIndex => _selectedTabIndex;
  set selectedTabIndex(int val) {
    _selectedTabIndex = val;
    notifyListeners();
  }

  List<Research> get physicsResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.physics).sortedBy((element) => element.order).toList();
  List<Research> get engineeringResearches => (researches == null)
      ? null
      : researches.where((element) => element.researchType == ResearchType.engineering).sortedBy((element) => element.order).toList();
  List<Research> get biologyResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.biology).sortedBy((element) => element.order).toList();
  List<Research> get socialResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.social).sortedBy((element) => element.order).toList();
  List<Research> get astronomyResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.astronomy).sortedBy((element) => element.order).toList();
  List<Research> get industryResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.industry).sortedBy((element) => element.order).toList();
  List<Research> get militaryResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.military).sortedBy((element) => element.order).toList();
  List<Research> get newWorldsResearches =>
      (researches == null) ? null : researches.where((element) => element.researchType == ResearchType.newWorlds).sortedBy((element) => element.order).toList();

  @override
  Future futureToRun() async {
    researches = await _fetchResearchesAsync();
  }

  Future<List<Research>> _fetchResearchesAsync() async {
    return await _researchProvider.get();
  }
}
