import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

part 'conveyor_building.g.dart';

@GuidConverter()
@JsonSerializable()
class ConveyorBuilding extends Building {
  ConveyorBuilding();

  factory ConveyorBuilding.fromJson(Map<String, dynamic> json) => _$ConveyorBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$ConveyorBuildingToJson(this);
}
