import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:json_annotation/json_annotation.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

part 'refinery_building.g.dart';

@GuidConverter()
@JsonSerializable()
class RefineryBuilding extends Building {
  RefineryBuilding();

  factory RefineryBuilding.fromJson(Map<String, dynamic> json) => _$RefineryBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$RefineryBuildingToJson(this);
}
