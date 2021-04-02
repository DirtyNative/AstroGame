import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/communications/repositories/built_building_repository.dart';
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

  BuildingViewModel(
    this._buildingRepository,
    this._builtBuildingRepository,
    @factoryParam this._building,
  );

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

  Future<ImageProvider> getImageAsync(Guid buildingId) async {
    var response =
        await _buildingRepository.getImageAsync(buildingId: buildingId);

    if (response.hasError) {
      throw Exception('Failed to load building image $buildingId');
    }

    return response.data;
  }
}
