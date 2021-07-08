import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/technology_value_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class TechnologyValue {
  @JsonKey()
  Guid technologyId;

  @JsonKey()
  int level;

  @JsonKey()
  List<ResourceAmount> technologyCosts;

  TechnologyValue();

  factory TechnologyValue.fromJson(Map<String, dynamic> json) =>
      TechnologyValueConverter().fromJson(json);
}
