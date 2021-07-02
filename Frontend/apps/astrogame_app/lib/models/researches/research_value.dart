import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'research_value.g.dart';

@GuidConverter()
@JsonSerializable()
class ResearchValue {
  Guid researchId;
  int level;

  List<ResourceAmount> researchCosts;

  ResearchValue();

  factory ResearchValue.fromJson(Map<String, dynamic> json) =>
      _$ResearchValueFromJson(json);
  Map<String, dynamic> toJson() => _$ResearchValueToJson(this);
}
