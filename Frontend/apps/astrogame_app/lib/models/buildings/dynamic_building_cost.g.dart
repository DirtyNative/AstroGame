// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dynamic_building_cost.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DynamicBuildingCost _$DynamicBuildingCostFromJson(Map<String, dynamic> json) {
  return DynamicBuildingCost()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..baseValue = (json['baseValue'] as num).toDouble()
    ..multiplier = (json['multiplier'] as num).toDouble();
}

Map<String, dynamic> _$DynamicBuildingCostToJson(
        DynamicBuildingCost instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'baseValue': instance.baseValue,
      'multiplier': instance.multiplier,
    };
