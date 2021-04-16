import 'dart:async';

import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/resource_snapshot_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:astrogame_app/extensions/duration_extensions.dart';

@injectable
class ResourceViewModel extends FutureViewModel {
  ResourceSnapshotProvider _resourceSnapshotProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  Timer _timer;

  ResourceViewModel(
    this._resourceSnapshotProvider,
    this._selectedColonizedStellarObjectProvider,
    @factoryParam this._resource,
  ) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  Resource _resource;
  Resource get resource => _resource;
  set resource(Resource val) {
    _resource = val;
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
