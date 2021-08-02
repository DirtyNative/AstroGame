import 'package:astrogame_app/events/server_events/buildings/technology_upgrade_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/technology_upgrade_started_event.dart';
import 'package:astrogame_app/providers/finished_technologies_provider.dart';
import 'package:astrogame_app/providers/fulfilled_conditions_provider.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/providers/technology_upgrades_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/communications/server_connection.dart';
import 'package:astrogame_app/communications/hubs/hub_base.dart';
import 'package:injectable/injectable.dart';
import 'package:signalr_core/signalr_core.dart';

@singleton
class TechnologyHub extends HubBase {
  EventService _eventService;
  FinishedTechnologiesProvider _constructedBuildingsProvider;
  StoredResourceProvider _storedResourceProvider;
  TechnologyUpgradesProvider _technologyUpgradesProvider;
  FulfilledConditionsProvider _fulfilledConditionsProvider;

  static const String TechnologyUpgradeStartedKey = 'TechnologyUpgradeStarted';
  static const String TechnologyUpgradeFinishedKey =
      'TechnologyUpgradeFinished';

  TechnologyHub(
    this._eventService,
    this._constructedBuildingsProvider,
    this._storedResourceProvider,
    this._technologyUpgradesProvider,
    this._fulfilledConditionsProvider,
    ServerConnection _serverConnection,
    HttpHeaderProvider _httpHeaderProvider,
  ) : super(_httpHeaderProvider, _serverConnection, '/hub/building') {}

  @override
  void registerEvents(HubConnection connection) {
    connection.on(TechnologyUpgradeStartedKey,
        (args) async => await onBuildingConstructionStarted(args));
    connection.on(TechnologyUpgradeFinishedKey,
        (args) async => await onBuildingConstructionFinished(args));
  }

  Future onBuildingConstructionStarted(List<dynamic>? args) async {
    await _technologyUpgradesProvider.updateAsync();
    await _storedResourceProvider.updateAsync();

    _eventService.fire(new TechnologyUpgradeStartedEvent());
  }

  Future onBuildingConstructionFinished(List<dynamic>? args) async {
    await _technologyUpgradesProvider.updateAsync();
    await _constructedBuildingsProvider.updateAsync();
    await _storedResourceProvider.updateAsync();
    _fulfilledConditionsProvider.reset();

    _eventService.fire(new TechnologyUpgradeFinishedEvent());
  }
}
