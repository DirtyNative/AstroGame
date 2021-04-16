import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

part 'manufacturing_facility_building.g.dart';

@GuidConverter()
@JsonSerializable()
class ManufacturingFacilityBuilding extends Building {
  ManufacturingFacilityBuilding();

  factory ManufacturingFacilityBuilding.fromJson(Map<String, dynamic> json) => _$ManufacturingFacilityBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$ManufacturingFacilityBuildingToJson(this);
}
