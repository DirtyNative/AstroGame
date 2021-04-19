import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'fixed_building_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class FixedBuildingCost extends BuildingCost {
  @JsonKey()
  double amount;

  FixedBuildingCost();

  factory FixedBuildingCost.fromJson(Map<String, dynamic> json) => _$FixedBuildingCostFromJson(json);
  Map<String, dynamic> toJson() => _$FixedBuildingCostToJson(this);
}
