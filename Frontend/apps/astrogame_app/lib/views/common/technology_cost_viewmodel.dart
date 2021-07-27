import 'package:astrogame_app/communications/repositories/technology_repository.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class TechnologyCostViewModel extends FutureViewModel {
  TechnologyRepository _technologyRepository;
  ResourceProvider _resourceProvider;

  Technology? technology;
  FinishedTechnology? finishedTechnology;

  TechnologyCostViewModel(
    this._technologyRepository,
    this._resourceProvider,
    @factoryParam this.technology,
    @factoryParam this.finishedTechnology,
  ) : assert(technology != null);

  late List<TechnologyValue> _technologyValues;
  List<TechnologyValue> get technologyValues => _technologyValues;
  set technologyValues(List<TechnologyValue> val) {
    _technologyValues = val;
    notifyListeners();
  }

  late List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    resources = await _fetchResourcesAsync();
    technologyValues = await _fetchResearchValues();
  }

  Future<List<Resource>> _fetchResourcesAsync() async {
    return await _resourceProvider.getAsync();
  }

  Future<List<TechnologyValue>> _fetchResearchValues() async {
    var response = await _technologyRepository.getValuesAsync(
        technology!.id, finishedTechnology?.level ?? 1, 10);

    if (response.hasError) {
      throw Exception(response.error);
    }

    return response.data ?? [];
  }
}
