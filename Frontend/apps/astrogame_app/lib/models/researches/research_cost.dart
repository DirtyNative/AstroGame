import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/research_cost_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
@JsonSerializable()
abstract class ResearchCost {
  Guid id;
  Guid researchId;
  Guid resourceId;

  ResearchCost();

  factory ResearchCost.fromJson(Map<String, dynamic> json) => ResearchCostConverter().fromJson(json);
}
