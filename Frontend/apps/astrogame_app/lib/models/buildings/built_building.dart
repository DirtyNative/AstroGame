import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'built_building.g.dart';

@GuidConverter()
@JsonSerializable()
class BuiltBuilding {
  Guid id;
  Guid buildingId;
  Guid colonizedStellarObjectId;
  int level;

  BuiltBuilding();

  factory BuiltBuilding.fromJson(Map<String, dynamic> json) =>
      _$BuiltBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$BuiltBuildingToJson(this);
}
