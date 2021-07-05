import 'package:astrogame_app/communications/repositories/research_repository.dart';
import 'package:astrogame_app/models/researches/research_value.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class TechnologyCostViewModel extends FutureViewModel {
  ResearchRepository _researchRepository;
  ResourceProvider _resourceProvider;

  Technology research;
  FinishedTechnology finishedTechnology;

  TechnologyCostViewModel(
    this._researchRepository,
    this._resourceProvider,
    @factoryParam this.research,
    @factoryParam this.finishedTechnology,
  );

  List<ResearchValue> _researchValues;
  List<ResearchValue> get researchValues => _researchValues;
  set researchValues(List<ResearchValue> val) {
    _researchValues = val;
    notifyListeners();
  }

  List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    resources = await _fetchResourcesAsync();
    researchValues = await _fetchResearchValues();
  }

  Future<List<Resource>> _fetchResourcesAsync() async {
    return await _resourceProvider.getAsync();
  }

  Future<List<ResearchValue>> _fetchResearchValues() async {
    var response = await _researchRepository.getValuesAsync(
        research.id, finishedTechnology?.level ?? 1, 10);

    if (response.hasError) {
      throw Exception(response.error);
    }

    return response.data;
  }
}
