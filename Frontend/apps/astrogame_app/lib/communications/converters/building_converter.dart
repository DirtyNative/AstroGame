import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/civil_building.dart';
import 'package:astrogame_app/models/buildings/conveyor_building.dart';
import 'package:astrogame_app/models/buildings/refinery_building.dart';
import 'package:astrogame_app/models/buildings/manufacturing_facility_building.dart';
import 'package:astrogame_app/models/buildings/research_laboratory_building.dart';
import 'package:astrogame_app/models/buildings/storage_building.dart';
import 'package:json_annotation/json_annotation.dart';

class BuildingConverter implements JsonConverter<Building, Map<String, dynamic>> {
  const BuildingConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'CivilBuilding') {
      return CivilBuilding.fromJson(json);
    } else if (type.value == 'ConveyorBuilding') {
      return ConveyorBuilding.fromJson(json);
    } else if (type.value == 'ManufacturingFacilityBuilding') {
      return ManufacturingFacilityBuilding.fromJson(json);
    } else if (type.value == 'RefineryBuilding') {
      return RefineryBuilding.fromJson(json);
    } else if (type.value == 'ResearchLaboratoryBuilding') {
      return ResearchLaboratoryBuilding.fromJson(json);
    } else if (type.value == 'StorageBuilding') {
      return StorageBuilding.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}
