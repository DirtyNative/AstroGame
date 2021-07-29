import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/enums/building_type.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:astrogame_app/views/technologies/technologies_viewmodel.dart';
import 'package:injectable/injectable.dart';
import 'package:dartx/dartx.dart';

@injectable
class BuildingsViewModel extends TechnologiesViewModel {
  BuildingsProvider buildingsProvider;

  BuildingsViewModel(
    this.buildingsProvider,
  );

  List<Building> get conveyorBuildings => (technologies as List<Building>)
      .where((element) => element.buildingType == BuildingType.conveyorBuilding)
      .sortedBy((element) => element.order)
      .toList();
  List<Building> get civilBuildings => (technologies as List<Building>)
      .where((element) => element.buildingType == BuildingType.civilBuilding)
      .sortedBy((element) => element.order)
      .toList();
  List<Building> get refineryBuildings => (technologies as List<Building>)
      .where((element) => element.buildingType == BuildingType.refineryBuilding)
      .sortedBy((element) => element.order)
      .toList();
  List<Building> get manufacturingFacilityBuildings => (technologies
          as List<Building>)
      .where((element) =>
          element.buildingType == BuildingType.manufacturingFacilityBuilding)
      .sortedBy((element) => element.order)
      .toList();
  List<Building> get researchLaboratoryBuildings => (technologies
          as List<Building>)
      .where((element) =>
          element.buildingType == BuildingType.researchLaboratoryBuilding)
      .sortedBy((element) => element.order)
      .toList();
  List<Building> get storageBuildings => (technologies as List<Building>)
      .where((element) => element.buildingType == BuildingType.storageBuilding)
      .sortedBy((element) => element.order)
      .toList();

  @override
  Future<List<Technology>> fetchTechnologiesAsync() async {
    return await buildingsProvider.get();
  }
}
