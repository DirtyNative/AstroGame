import 'dart:async';

import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/events/data_updated_event.dart';
import 'package:astrogame_app/executers/build_building_executer.dart';
import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:duration/duration.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingViewModel extends FutureViewModel {
  BuildingRepository _buildingRepository;

  ConstructedBuildingsProvider _constructedBuildingsProvider;
  BuildingChainProvider _buildingChainProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  BuildBuildingExecuter _buildBuildingExecuter;

  EventService _eventService;
  ResourceHelper _resourceHelper;

  Timer _timer;

  Building _building;
  Building get building => _building;
  set building(Building val) {
    _building = val;
    notifyListeners();
  }

  BuiltBuilding _builtBuilding;
  BuiltBuilding get builtBuilding => _builtBuilding;
  set builtBuilding(BuiltBuilding val) {
    _builtBuilding = val;
    notifyListeners();
  }

  BuildingConstruction _buildingConstruction;
  BuildingConstruction get buildingConstruction => _buildingConstruction;
  set buildingConstruction(BuildingConstruction val) {
    _buildingConstruction = val;
    notifyListeners();
  }

  BuildingViewModel(
    this._buildingRepository,
    this._buildingChainProvider,
    this._constructedBuildingsProvider,
    this._selectedColonizedStellarObjectProvider,
    this._buildBuildingExecuter,
    this._eventService,
    this._resourceHelper,
    @factoryParam this._building,
  ) {
    _eventService.on<DataUpdatedEvent>().listen((event) async {
      await updateAsync();
      notifyListeners();
    });

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  bool get isConstructable {
    // If there is a construction running on this StellarObject
    if (this.buildingConstruction != null) {
      return false;
    }

    var level = 0;

    if (builtBuilding != null) {
      level = builtBuilding.level;
    }

    return _resourceHelper.hasStoredResourcesToBuild(building, level);
  }

  String get constructionText {
    // If this building is under construction
    if (buildingConstruction != null &&
        buildingConstruction.buildingId == building.id) {
      var duration =
          _buildingConstruction.endTime.difference(DateTime.now().toUtc());

      if (duration < Duration()) {
        duration = Duration();
      }

      return prettyDuration(duration, abbreviated: true, delimiter: ' : ');
    }

    return (builtBuilding == null)
        ? 'Build'
        : 'Upgrade ${builtBuilding.level + 1}';
  }

  Future<BuiltBuilding> _fetchBuiltBuildingAsync(Guid buildingId) async {
    return await _constructedBuildingsProvider.getByBuildingAsync(buildingId);
  }

  Future<BuildingConstruction> _fetchActiveConstruction() async {
    return await _buildingChainProvider.getByStellarObject(
        _selectedColonizedStellarObjectProvider
            .getSelectedObject()
            .stellarObjectId);
  }

  Future<ImageProvider> fetchImageAsync(Guid buildingId) async {
    var response =
        await _buildingRepository.getImageAsync(buildingId: buildingId);

    if (response.hasError) {
      throw Exception('Failed to load building image $buildingId');
    }

    return response.data;
  }

  Future buildAsync() async {
    await _buildBuildingExecuter.buildBuildingAsync(building.id);
  }

  Future updateAsync() async {
    builtBuilding = await _fetchBuiltBuildingAsync(building.id);
    buildingConstruction = await _fetchActiveConstruction();

    print(buildingConstruction);
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Future futureToRun() => updateAsync();
}
