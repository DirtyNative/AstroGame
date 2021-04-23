import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'dynamic_research_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class DynamicResearchCost extends ResearchCost {
  double baseValue;
  double multiplier;

  DynamicResearchCost();

  factory DynamicResearchCost.fromJson(Map<String, dynamic> json) => _$DynamicResearchCostFromJson(json);
  Map<String, dynamic> toJson() => _$DynamicResearchCostToJson(this);
}
