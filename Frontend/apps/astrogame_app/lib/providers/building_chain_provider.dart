import 'package:astrogame_app/communications/repositories/building_chain_repository.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingChainProvider {
  BuildingChain _buildingChain;

  BuildingChainRepository _buildingChainRepository;

  BuildingChainProvider(this._buildingChainRepository);

  Future<BuildingChain> get() async {
    var lock = new Lock();

    return await lock.synchronized(() async {
      if (_buildingChain != null) {
        return _buildingChain;
      }

      var response = await _buildingChainRepository.getByCurrentPlayerAsync();

      _buildingChain = response.data;
      return _buildingChain;
    });
  }

  Future<BuildingConstruction> getByStellarObject(Guid stellarObjectId) async {
    var buildingChain = await get();

    if (buildingChain == null) {
      return null;
    }

    // If there is no construction in progress on the given stellar object
    if (buildingChain.buildingUpgrades
            .any((element) => element.stellarObjectId == stellarObjectId) ==
        false) {
      return null;
    }

    return buildingChain.buildingUpgrades
        .firstWhere((element) => element.stellarObjectId == stellarObjectId);
  }
}
