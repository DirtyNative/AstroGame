import 'dart:async';

import 'package:astrogame_app/events/view_events/resources_updated_event.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:astrogame_app/providers/resource_snapshot_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:astrogame_app/extensions/duration_extensions.dart';

@injectable
class ResourceViewModel extends FutureViewModel {
  EventService _eventService;

  ResourceSnapshotProvider _resourceSnapshotProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  Timer _timer;

  ResourceViewModel(
    this._eventService,
    this._resourceSnapshotProvider,
    this._selectedColonizedStellarObjectProvider,
    @factoryParam this._resource,
    @factoryParam this._technologyCost,
  ) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });

    _eventService.on<ResourcesUpdatedEvent>().listen((event) async {
      _resourceSnapshot = await _fetchResourceSnapshotAsync();
    });
  }

  Resource _resource;
  Resource get resource => _resource;
  set resource(Resource val) {
    _resource = val;
    notifyListeners();
  }

  TechnologyCost _technologyCost;
  TechnologyCost get technologyCost => _technologyCost;
  set technologyCost(TechnologyCost val) {
    _technologyCost = val;
    notifyListeners();
  }

  ResourceSnapshot _resourceSnapshot;
  ResourceSnapshot get resourceSnapshot => _resourceSnapshot;
  set resourceSnapshot(ResourceSnapshot val) {
    _resourceSnapshot = val;
    notifyListeners();
  }

  double get storedAmount {
    if (storedResource == null) {
      return 0;
    }

    var elapsedTime =
        resourceSnapshot.snapshotTime.difference(DateTime.now().toUtc());
    return storedResource.amount +
        storedResource.hourlyAmount * elapsedTime.abs().totalHours;
  }

  double get neededAmount {
    return (_technologyCost as OneTimeResearchCost).amount;
  }

  StoredResource get storedResource {
    if (resourceSnapshot == null) {
      return null;
    }

    if (resourceSnapshot.storedResources
            .any((element) => element.resourceId == resource.id) ==
        false) {
      return null;
    }

    return resourceSnapshot.storedResources
        .firstWhere((element) => element.resourceId == resource.id);
  }

  Future<ResourceSnapshot> _fetchResourceSnapshotAsync() async {
    var selectedStellarObjectId = _selectedColonizedStellarObjectProvider
        .getSelectedObject()
        .stellarObjectId;

    return _resourceSnapshotProvider.getAsync(selectedStellarObjectId);
  }

  @override
  Future futureToRun() async {
    _resourceSnapshot = await _fetchResourceSnapshotAsync();
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
