import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:injectable/injectable.dart';

@singleton
class StoredResourceProvider {
  List<StoredResource> _storedResources = [];

  List<StoredResource> getStoredRecources() => _storedResources;
  void setStoredResources(List<StoredResource> val) => _storedResources = val;
}
