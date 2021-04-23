// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dynamic_research_cost.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DynamicResearchCost _$DynamicResearchCostFromJson(Map<String, dynamic> json) {
  return DynamicResearchCost()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..researchId = const GuidConverter().fromJson(json['researchId'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..baseValue = (json['baseValue'] as num)?.toDouble()
    ..multiplier = (json['multiplier'] as num)?.toDouble();
}

Map<String, dynamic> _$DynamicResearchCostToJson(
        DynamicResearchCost instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'researchId': const GuidConverter().toJson(instance.researchId),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'baseValue': instance.baseValue,
      'multiplier': instance.multiplier,
    };
