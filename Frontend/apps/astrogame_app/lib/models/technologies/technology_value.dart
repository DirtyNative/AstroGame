import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:json_annotation/json_annotation.dart';

part 'technology_value.g.dart';

@GuidConverter()
@JsonSerializable()
class TechnologyValue {
  int level;

  List<ResourceAmount> technologyCosts;

  TechnologyValue();

  factory TechnologyValue.fromJson(Map<String, dynamic> json) =>
      _$TechnologyValueFromJson(json);
  Map<String, dynamic> toJson() => _$TechnologyValueToJson(this);
}
