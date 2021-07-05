// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResearchValue _$ResearchValueFromJson(Map<String, dynamic> json) {
  return ResearchValue()
    ..level = json['level'] as int
    ..technologyCosts = (json['technologyCosts'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..researchId = const GuidConverter().fromJson(json['researchId'] as String);
}

Map<String, dynamic> _$ResearchValueToJson(ResearchValue instance) =>
    <String, dynamic>{
      'level': instance.level,
      'technologyCosts': instance.technologyCosts,
      'researchId': const GuidConverter().toJson(instance.researchId),
    };
