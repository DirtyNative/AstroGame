import 'package:astrogame_app/models/resources/resource.dart';
import 'package:injectable/injectable.dart';

@singleton
class ResourceProvider {
  List<Resource> _resources;

  List<Resource> getResources() => _resources;
  void setResources(List<Resource> val) => _resources = val;
}
