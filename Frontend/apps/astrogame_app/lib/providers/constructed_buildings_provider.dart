import 'package:astrogame_app/communications/repositories/built_building_repository.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ConstructedBuildingsProvider {
  BuiltBuildingRepository _builtBuildingRepository;

  List<BuiltBuilding> _constructedBuildings;

  ConstructedBuildingsProvider(this._builtBuildingRepository);

  Future<List<BuiltBuilding>> get() async {
    var lock = new Lock();

    return await lock.synchronized(() async {
      if (_constructedBuildings != null) {
        return _constructedBuildings;
      }

      var response = await _builtBuildingRepository.getAsync();

      _constructedBuildings = response.data;
      return _constructedBuildings;
    });
  }

  void set(List<BuiltBuilding> val) {
    _constructedBuildings = val;
  }

  Future<BuiltBuilding> getByBuildingAsync(Guid buildingId) async {
    var buildings = await get();

    if (buildings == null || buildings.length == 0) {
      return null;
    }

    if (buildings.any((element) => element.buildingId == buildingId) == false) {
      return null;
    }

    return buildings.firstWhere((element) => element.buildingId == buildingId);
  }
}
