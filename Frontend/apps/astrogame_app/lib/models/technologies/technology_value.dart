import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/technology_value_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class TechnologyValue {
  @JsonKey()
  late Guid technologyId;

  @JsonKey()
  late int level;

  @JsonKey()
  List<ResourceAmount> technologyCosts = [];

  TechnologyValue();

  factory TechnologyValue.fromJson(Map<String, dynamic> json) =>
      TechnologyValueConverter().fromJson(json);
}
