import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/enums/building_type.dart';
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

  List<Building> get conveyorBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.conveyorBuilding).sortedBy((element) => element.order).toList();
  List<Building> get civilBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.civilBuilding).sortedBy((element) => element.order).toList();
  List<Building> get refineryBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.refineryBuilding).sortedBy((element) => element.order).toList();
  List<Building> get manufacturingFacilityBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.manufacturingFacilityBuilding).sortedBy((element) => element.order).toList();
  List<Building> get researchLaboratoryBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.researchLaboratoryBuilding).sortedBy((element) => element.order).toList();
  List<Building> get storageBuildings => (buildings == null)
      ? null
      : buildings.where((element) => element.buildingType == BuildingType.storageBuilding).sortedBy((element) => element.order).toList();

  Future<List<Building>> _fetchBuildingsAsync() async {
    return await buildingsProvider.get();
  }

  @override
  Future futureToRun() async {
    buildings = await _fetchBuildingsAsync();
  }
}
