import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
import 'input_resource.dart';
import 'output_resource.dart';
import 'building_cost.dart';
import 'package:astrogame_app/models/enums/building_type.dart';

part 'fixed_building.g.dart';

@GuidConverter()
@JsonSerializable()
class FixedBuilding extends Building {
  FixedBuilding();

  factory FixedBuilding.fromJson(Map<String, dynamic> json) =>
      _$FixedBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$FixedBuildingToJson(this);
}
