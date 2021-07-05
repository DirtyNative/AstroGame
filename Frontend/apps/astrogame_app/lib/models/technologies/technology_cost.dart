import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/technology_cost_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class TechnologyCost {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  Guid technologyId;

  TechnologyCost();

  factory TechnologyCost.fromJson(Map<String, dynamic> json) =>
      TechnologyCostConverter().fromJson(json);
  Map<String, dynamic> toJson() => TechnologyCostConverter().toJson(this);
}
