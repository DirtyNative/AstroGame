// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResearchValue _$ResearchValueFromJson(Map<String, dynamic> json) {
  return ResearchValue()
    ..researchId = const GuidConverter().fromJson(json['researchId'] as String)
    ..level = json['level'] as int
    ..researchCosts = (json['researchCosts'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$ResearchValueToJson(ResearchValue instance) =>
    <String, dynamic>{
      'researchId': const GuidConverter().toJson(instance.researchId),
      'level': instance.level,
      'researchCosts': instance.researchCosts,
    };
