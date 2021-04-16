import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/civil_building.dart';
import 'package:astrogame_app/models/buildings/conveyor_building.dart';
import 'package:astrogame_app/models/buildings/refinery_building.dart';
import 'package:astrogame_app/models/buildings/storage_building.dart';
import 'package:astrogame_app/models/buildings/manufacturing_facility_building.dart';
import 'package:astrogame_app/models/buildings/research_laboratory_building.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:dartx/dartx.dart';

@injectable
class BuildingsViewModel extends FutureViewModel {
  BuildingsProvider buildingsProvider;

  BuildingsViewModel(
    this.buildingsProvider,
  );

  List<Building> _buildings;
  List<Building> get buildings => _buildings;
  set buildings(List<Building> val) {
    _buildings = val;
    notifyListeners();
  }

  int _selectedTabIndex = 0;
  int get selectedTabIndex => _selectedTabIndex;
  set selectedTabIndex(int val) {
    _selectedTabIndex = val;
    notifyListeners();
  }

  List<Building> get conveyorBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is ConveyorBuilding).sortedBy((element) => element.order).toList();
  List<Building> get civilBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is CivilBuilding).sortedBy((element) => element.order).toList();
  List<Building> get refineryBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is RefineryBuilding).sortedBy((element) => element.order).toList();
  List<Building> get manufacturingFacilityBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is ManufacturingFacilityBuilding).sortedBy((element) => element.order).toList();
  List<Building> get researchLaboratoryBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is ResearchLaboratoryBuilding).sortedBy((element) => element.order).toList();
  List<Building> get storageBuildings =>
      (buildings == null) ? null : buildings.where((element) => element is StorageBuilding).sortedBy((element) => element.order).toList();

  Future<List<Building>> _fetchBuildingsAsync() async {
    return await buildingsProvider.get();
  }

  @override
  Future futureToRun() async {
    buildings = await _fetchBuildingsAsync();
  }
}
