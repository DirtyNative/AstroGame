import 'package:json_annotation/json_annotation.dart';

enum BuildingType {
  @JsonValue(0)
  civilBuilding,

  @JsonValue(1)
  conveyorBuilding,

  @JsonValue(2)
  manufacturingFacilityBuilding,

  @JsonValue(3)
  refineryBuilding,

  @JsonValue(4)
  researchLaboratoryBuilding,

  @JsonValue(5)
  storageBuilding,
}
