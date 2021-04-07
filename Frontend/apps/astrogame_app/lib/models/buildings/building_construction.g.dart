// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_construction.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingConstruction _$BuildingConstructionFromJson(Map<String, dynamic> json) {
  return BuildingConstruction()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..buildingChainId =
        const GuidConverter().fromJson(json['buildingChainId'] as String)
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..stellarObjectId =
        const GuidConverter().fromJson(json['stellarObjectId'] as String)
    ..startTime = json['startTime'] == null
        ? null
        : DateTime.parse(json['startTime'] as String)
    ..endTime = json['endTime'] == null
        ? null
        : DateTime.parse(json['endTime'] as String)
    ..hangdireJobId = json['hangdireJobId'] as String;
}

Map<String, dynamic> _$BuildingConstructionToJson(
        BuildingConstruction instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'buildingChainId': const GuidConverter().toJson(instance.buildingChainId),
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
      'startTime': instance.startTime?.toIso8601String(),
      'endTime': instance.endTime?.toIso8601String(),
      'hangdireJobId': instance.hangdireJobId,
    };
