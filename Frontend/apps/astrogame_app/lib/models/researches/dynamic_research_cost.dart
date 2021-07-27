import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/dynamic_cost.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'dynamic_research_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class DynamicResearchCost extends TechnologyCost with DynamicCost {
  late double baseValue;
  late double multiplier;

  DynamicResearchCost();

  factory DynamicResearchCost.fromJson(Map<String, dynamic> json) =>
      _$DynamicResearchCostFromJson(json);
  Map<String, dynamic> toJson() => _$DynamicResearchCostToJson(this);
}
