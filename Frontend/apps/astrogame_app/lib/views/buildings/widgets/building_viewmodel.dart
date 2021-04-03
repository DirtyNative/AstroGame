import 'dart:async';

import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/communications/repositories/built_building_repository.dart';
import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingViewModel extends FutureViewModel {
  BuildingRepository _buildingRepository;
  BuiltBuildingRepository _builtBuildingRepository;

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

  bool _hasEnoughResourcesToBuild = false;
  bool get hasEnoughResourcesToBuild => _hasEnoughResourcesToBuild;
  set hasEnoughResourcesToBuild(bool val) {
    _hasEnoughResourcesToBuild = val;
    notifyListeners();
  }

  BuildingViewModel(
    this._buildingRepository,
    this._builtBuildingRepository,
    this._resourceHelper,
    @factoryParam this._building,
  ) {
    _calculateBuildable();

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      _calculateBuildable();
    });
  }

  @override
  Future futureToRun() async {
    var response =
        await _builtBuildingRepository.getByBuildingAsync(_building.id);

    if (response.hasError) {
      // TODO: show error
      return;
    }

    _builtBuilding = response.data;
  }

  void _calculateBuildable() {
    var level = 0;

    if (builtBuilding != null) {
      level = builtBuilding.level;
    }

    hasEnoughResourcesToBuild =
        _resourceHelper.hasStoredResourcesToBuild(building, level);
  }

  Future<ImageProvider> getImageAsync(Guid buildingId) async {
    var response =
        await _buildingRepository.getImageAsync(buildingId: buildingId);

    if (response.hasError) {
      throw Exception('Failed to load building image $buildingId');
    }

    return response.data;
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
