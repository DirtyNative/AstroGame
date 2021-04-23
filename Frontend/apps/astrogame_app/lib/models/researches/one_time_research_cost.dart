import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:json_annotation/json_annotation.dart';

part 'one_time_research_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class OneTimeResearchCost extends ResearchCost {
  double amount;

  OneTimeResearchCost();

  factory OneTimeResearchCost.fromJson(Map<String, dynamic> json) => _$OneTimeResearchCostFromJson(json);
  Map<String, dynamic> toJson() => _$OneTimeResearchCostToJson(this);
}
