import 'dart:async';

import 'package:astrogame_app/events/view_events/resources_updated_event.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/services/event_service.dart';

import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ResourceViewModel extends FutureViewModel {
  EventService _eventService;

  ResourceProvider _resourceProvider;
  StoredResourceProvider _storedResourceProvider;

  late Timer _timer;

  List<Resource> _resources = [];
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  List<StoredResource> _storedResources = [];
  List<StoredResource> get storedResources => _storedResources;
  set storedResources(List<StoredResource> val) {
    _storedResources = val;
    notifyListeners();
  }

  ResourceViewModel(
    this._eventService,
    this._resourceProvider,
    this._storedResourceProvider,
  ) {
    _eventService.on<ResourcesUpdatedEvent>().listen((event) async {
      storedResources = await _storedResourceProvider.updateAsync();
    });

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      for (int index = 0; index < storedResources.length; index++) {
        storedResources[index].amount +=
            storedResources[index].hourlyAmount * (1 / 3600);
      }

      notifyListeners();
    });
  }

  @override
  Future futureToRun() async {
    resources = await _resourceProvider.getAsync();
    storedResources = await _storedResourceProvider.getAsync();
  }

  Resource getResource(Guid resourceId) =>
      resources.firstWhere((element) => element.id == resourceId);

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
