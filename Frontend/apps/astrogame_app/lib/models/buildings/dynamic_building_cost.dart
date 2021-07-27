import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/dynamic_cost.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'dynamic_building_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class DynamicBuildingCost extends TechnologyCost with DynamicCost {
  @JsonKey()
  late double baseValue;

  @JsonKey()
  late double multiplier;

  DynamicBuildingCost();

  factory DynamicBuildingCost.fromJson(Map<String, dynamic> json) =>
      _$DynamicBuildingCostFromJson(json);
  Map<String, dynamic> toJson() => _$DynamicBuildingCostToJson(this);
}
