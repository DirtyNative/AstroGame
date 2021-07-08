import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/technology_converter.dart';
import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class Technology {
  @JsonKey()
  Guid id;

  @JsonKey()
  String name;

  @JsonKey()
  String description;

  @JsonKey()
  String assetName;

  @JsonKey()
  int order;

  @JsonKey()
  List<Condition> neededConditions;

  @JsonKey()
  List<Condition> conditionFor;

  @JsonKey()
  List<TechnologyCost> technologyCosts;

  Technology();

  factory Technology.fromJson(Map<String, dynamic> json) =>
      TechnologyConverter().fromJson(json);

  Map<String, dynamic> toJson() => TechnologyConverter().toJson(this);
}
