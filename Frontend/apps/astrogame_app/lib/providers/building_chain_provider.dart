import 'package:astrogame_app/communications/repositories/building_chain_repository.dart';
import 'package:astrogame_app/events/data_updated_event.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingChainProvider {
  BuildingChain _buildingChain;

  BuildingChainRepository _buildingChainRepository;
  EventService _eventService;

  BuildingChainProvider(
    this._buildingChainRepository,
    this._eventService,
  );

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

  Future updateAsync() async {
    var lock = new Lock();

    return await lock.synchronized(() async {
      var response = await _buildingChainRepository.getByCurrentPlayerAsync();

      _buildingChain = response.data;

      _eventService.fire(new DataUpdatedEvent());
    });
  }
}
