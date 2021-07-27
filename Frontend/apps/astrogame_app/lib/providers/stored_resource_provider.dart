import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/building_construction_started_event.dart';
import 'package:astrogame_app/events/view_events/resources_updated_event.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/resource_snapshot_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:injectable/injectable.dart';

@singleton
class StoredResourceProvider {
  EventService _eventService;

  ResourceSnapshotProvider _resourceSnapshotProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  StoredResourceProvider(
    this._eventService,
    this._resourceSnapshotProvider,
    this._selectedColonizedStellarObjectProvider,
  ) {
    _eventService.on<BuildingConstructionStartedEvent>().listen((event) async {
      await updateAsync();
      _eventService.fire(new ResourcesUpdatedEvent());
    });

    _eventService.on<BuildingConstructionFinishedEvent>().listen((event) async {
      await updateAsync();
      _eventService.fire(new ResourcesUpdatedEvent());
    });
  }

  Future<List<StoredResource>> getAsync() async {
    return await updateAsync();
  }

  Future<List<StoredResource>> updateAsync() async {
    var selectedColonizedStellarObject =
        _selectedColonizedStellarObjectProvider.getSelectedObject();

    if (selectedColonizedStellarObject == null) {
      return [];
    }

    var currentStellarObjectId = selectedColonizedStellarObject.stellarObjectId;

    var snapshot =
        await _resourceSnapshotProvider.getAsync(currentStellarObjectId);

    return snapshot?.storedResources ?? [];
  }
}
