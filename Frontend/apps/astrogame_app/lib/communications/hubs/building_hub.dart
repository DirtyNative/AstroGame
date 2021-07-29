import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/building_construction_started_event.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/communications/server_connection.dart';
import 'package:astrogame_app/communications/hubs/hub_base.dart';
import 'package:injectable/injectable.dart';
import 'package:signalr_core/signalr_core.dart';

@singleton
class TechnologyHub extends HubBase {
  EventService _eventService;
  BuildingChainProvider _buildingChainProvider;
  ConstructedBuildingsProvider _constructedBuildingsProvider;
  StoredResourceProvider _storedResourceProvider;

  static const String BuildingConstructionFinishedKey =
      'BuildingConstructionFinished';
  static const String BuildingConstructionStartedKey =
      'BuildingConstructionStarted';

  TechnologyHub(
    this._eventService,
    this._buildingChainProvider,
    this._constructedBuildingsProvider,
    this._storedResourceProvider,
    ServerConnection _serverConnection,
    HttpHeaderProvider _httpHeaderProvider,
  ) : super(_httpHeaderProvider, _serverConnection, '/hub/building') {}

  @override
  void registerEvents(HubConnection connection) {
    connection.on(BuildingConstructionFinishedKey,
        (args) async => await onBuildingConstructionStarted(args));
    connection.on(BuildingConstructionFinishedKey,
        (args) async => await onBuildingConstructionFinished(args));
  }

  Future onBuildingConstructionStarted(List<dynamic>? args) async {
    await _buildingChainProvider.updateAsync();
    await _storedResourceProvider.updateAsync();

    _eventService.fire(new BuildingConstructionStartedEvent());
  }

  Future onBuildingConstructionFinished(List<dynamic>? args) async {
    await _buildingChainProvider.updateAsync();
    await _constructedBuildingsProvider.updateAsync();
    await _storedResourceProvider.updateAsync();

    _eventService.fire(new BuildingConstructionFinishedEvent());
  }
}
