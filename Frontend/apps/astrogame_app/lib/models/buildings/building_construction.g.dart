// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_construction.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingConstruction _$BuildingConstructionFromJson(Map<String, dynamic> json) {
  return BuildingConstruction()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..startTime = DateTime.parse(json['startTime'] as String)
    ..endTime = DateTime.parse(json['endTime'] as String)
    ..hangfireJobId = json['hangfireJobId'] as String
    ..buildingChainId =
        const GuidConverter().fromJson(json['buildingChainId'] as String)
    ..stellarObjectId =
        const GuidConverter().fromJson(json['stellarObjectId'] as String);
}

Map<String, dynamic> _$BuildingConstructionToJson(
        BuildingConstruction instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'startTime': instance.startTime.toIso8601String(),
      'endTime': instance.endTime.toIso8601String(),
      'hangfireJobId': instance.hangfireJobId,
      'buildingChainId': const GuidConverter().toJson(instance.buildingChainId),
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
    };
