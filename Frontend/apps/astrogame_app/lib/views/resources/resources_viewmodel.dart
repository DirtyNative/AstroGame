import 'package:astrogame_app/models/resources/element.dart';
import 'package:astrogame_app/models/resources/material.dart';
import 'package:astrogame_app/models/resources/material_type.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:dartx/dartx.dart';

@injectable
class ResourcesViewModel extends FutureViewModel {
  ResourceProvider _resourceProvider;

  ResourcesViewModel(
    this._resourceProvider,
  );

  int _selectedTabIndex = 0;
  int get selectedTabIndex => _selectedTabIndex;
  set selectedTabIndex(int val) {
    _selectedTabIndex = val;
    notifyListeners();
  }

  late List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  List<Element> get elements {
    return resources.whereType<Element>().toList();
  }

  List<Material> get materials {
    return resources.whereType<Material>().toList();
  }

  List<Material> get buildingMaterials => materials
      .where((element) => element.type == MaterialType.building)
      .sortedBy((element) => element.name)
      .toList();
  List<Material> get consumableMaterials => materials
      .where((element) => element.type == MaterialType.consumables)
      .sortedBy((element) => element.name)
      .toList();
  List<Material> get componentMaterials => materials
      .where((element) => element.type == MaterialType.components)
      .sortedBy((element) => element.name)
      .toList();
  List<Material> get alloyMaterials => materials
      .where((element) => element.type == MaterialType.alloys)
      .sortedBy((element) => element.name)
      .toList();
  List<Material> get fuelMaterials => materials
      .where((element) => element.type == MaterialType.fuels)
      .sortedBy((element) => element.name)
      .toList();

  @override
  Future futureToRun() async {
    await _fetchResourcesAsync();
  }

  Future _fetchResourcesAsync() async {
    resources = await _resourceProvider.getAsync();
  }
}
