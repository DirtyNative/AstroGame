import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'building_cost.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingCost {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  Guid buildingId;

  @JsonKey()
  double baseValue;

  @JsonKey()
  double multiplier;

  BuildingCost();

  factory BuildingCost.fromJson(Map<String, dynamic> json) =>
      _$BuildingCostFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingCostToJson(this);
}
