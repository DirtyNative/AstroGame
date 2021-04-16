import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
part 'civil_building.g.dart';

@GuidConverter()
@JsonSerializable()
class CivilBuilding extends Building {
  CivilBuilding();

  factory CivilBuilding.fromJson(Map<String, dynamic> json) => _$CivilBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$CivilBuildingToJson(this);
}
