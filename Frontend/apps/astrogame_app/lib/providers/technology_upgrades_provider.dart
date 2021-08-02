import 'package:astrogame_app/communications/repositories/technology_upgrade_repository.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_technology_upgrade.dart';
import 'package:astrogame_app/models/technologies/player_dependent_technology_upgrade.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';
import 'package:collection/collection.dart';

@singleton
class TechnologyUpgradesProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  TechnologyUpgradeRepository _technologyUpgradeRepository;

  TechnologyUpgradesProvider(this._technologyUpgradeRepository);

  Future<List<TechnologyUpgrade>> get() async {
    var values = _memoryCache.get('all');

    if (values != null) {
      return values;
    }

    return await updateAsync();
  }

  Future<List<TechnologyUpgrade>> updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _technologyUpgradeRepository.getAllAsync();

      _memoryCache.put('all', response.data);
      return response.data ?? [];
    });
  }

  Future<TechnologyUpgrade?> getOnStellarObjectAsync(
      Guid stellarObjectId) async {
    var upgrades = await get();

    return upgrades.firstWhereOrNull((element) =>
        element is StellarObjectDependentTechnologyUpgrade &&
        element.stellarObjectId == stellarObjectId);
  }

  Future<TechnologyUpgrade?> getByTechnologyAsync(Guid technologyId) async {
    var upgrades = await get();

    return upgrades
        .firstWhereOrNull((element) => element.technologyId == technologyId);
  }

  Future<List<TechnologyUpgrade>> getStellarObjectDependentAsync() async {
    var upgrades = await get();

    return upgrades
        .whereType<StellarObjectDependentTechnologyUpgrade>()
        .toList();
  }

  Future<List<TechnologyUpgrade>> getPlayerDependentAsync() async {
    var technologies = await get();

    return technologies.whereType<PlayerDependentTechnologyUpgrade>().toList();
  }
}
