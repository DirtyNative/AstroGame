import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'building_value.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingValue {
  Guid buildingId;
  int level;

  List<ResourceAmount> buildingConsumptions;
  List<ResourceAmount> buildingProductions;
  List<ResourceAmount> buildingCosts;

  BuildingValue();

  factory BuildingValue.fromJson(Map<String, dynamic> json) => _$BuildingValueFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingValueToJson(this);
}
