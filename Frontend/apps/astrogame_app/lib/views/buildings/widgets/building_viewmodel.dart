import 'dart:async';

import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/executers/build_building_executer.dart';
import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:duration/duration.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingViewModel extends BaseViewModel {
  BuildingRepository _buildingRepository;
  ConstructedBuildingsProvider _constructedBuildingsProvider;

  BuildBuildingExecuter _buildBuildingExecuter;

  ResourceHelper _resourceHelper;

  Timer _timer;

  String getconstructionText(BuiltBuilding builtBuilding) {
    // If this building is under construction
    if (buildingConstruction != null &&
        buildingConstruction.buildingId == building.id) {
      return prettyDuration(
          _buildingConstruction.startTime.difference(DateTime.now()),
          abbreviated: true,
          delimiter: ' : ');
    }

    return (builtBuilding == null)
        ? 'Build'
        : 'Upgrade ${builtBuilding.level + 1}';
  }

  Building _building;
  Building get building => _building;
  set building(Building val) {
    _building = val;
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
    this._resourceHelper,
    this._buildBuildingExecuter,
    this._constructedBuildingsProvider,
    @factoryParam this._building,
    @factoryParam this._buildingConstruction,
  ) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  bool isConstructable(BuiltBuilding builtBuilding) {
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

  Future<BuiltBuilding> getBuiltBuildingAsync(Guid buildingId) {
    return _constructedBuildingsProvider.getByBuildingAsync(buildingId);
  }

  Future<ImageProvider> getImageAsync(Guid buildingId) async {
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

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
