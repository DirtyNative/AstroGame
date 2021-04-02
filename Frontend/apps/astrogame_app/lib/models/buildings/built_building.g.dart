// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'built_building.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuiltBuilding _$BuiltBuildingFromJson(Map<String, dynamic> json) {
  return BuiltBuilding()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..colonizedStellarObjectId = const GuidConverter()
        .fromJson(json['colonizedStellarObjectId'] as String)
    ..level = json['level'] as int;
}

Map<String, dynamic> _$BuiltBuildingToJson(BuiltBuilding instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'colonizedStellarObjectId':
          const GuidConverter().toJson(instance.colonizedStellarObjectId),
      'level': instance.level,
    };
