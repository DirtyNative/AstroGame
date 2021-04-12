import 'package:astrogame_app/communications/repositories/building_chain_repository.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingChainProvider {
  MemoryCache _memoryCache = MemoryCache();
  var _lock = new Lock();

  BuildingChainRepository _buildingChainRepository;

  BuildingChainProvider(
    this._buildingChainRepository,
  );

  Future<BuildingChain> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _buildingChainRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
      return response.data;
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

  Future updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _buildingChainRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
    });
  }

  Future removeFromStellarObjectAsync(Guid stellarObjectId) async {
    return await _lock.synchronized(() async {
      var chain = _memoryCache.get('all') as BuildingChain;

      chain.buildingUpgrades
          .removeWhere((element) => element.stellarObjectId == stellarObjectId);
    });
  }
}
