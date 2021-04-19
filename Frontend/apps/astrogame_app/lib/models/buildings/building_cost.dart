import 'package:astrogame_app/communications/converters/building_cost_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
@JsonSerializable()
abstract class BuildingCost {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  Guid buildingId;

  BuildingCost();

  factory BuildingCost.fromJson(Map<String, dynamic> json) => BuildingCostConverter().fromJson(json);
}
