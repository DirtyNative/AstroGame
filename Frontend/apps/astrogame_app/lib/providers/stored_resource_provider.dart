import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/resource_snapshot_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:injectable/injectable.dart';

@singleton
class StoredResourceProvider {
  ResourceSnapshotProvider _resourceSnapshotProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  StoredResourceProvider(
    this._resourceSnapshotProvider,
    this._selectedColonizedStellarObjectProvider,
  );

  Future<List<StoredResource>> getAsync() async {
    var currentStellarObjectId = _selectedColonizedStellarObjectProvider
        .getSelectedObject()
        .stellarObjectId;

    var snapshot =
        await _resourceSnapshotProvider.getAsync(currentStellarObjectId);

    return snapshot.storedResources;
  }

  Future<List<StoredResource>> updateAsync() async {
    var currentStellarObjectId = _selectedColonizedStellarObjectProvider
        .getSelectedObject()
        .stellarObjectId;

    var snapshot =
        await _resourceSnapshotProvider.updateAsync(currentStellarObjectId);

    return snapshot.storedResources;
  }
}
